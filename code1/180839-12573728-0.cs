        public static void MyMethod<IEnumType>(ref IEnumerable<IEnumType> ienum)
        {
            using (DataTable dt = new DataTable())
            {
                ienum.First(ie => true).GetType().GetProperties().ToList().ForEach(pr => dt.Columns.Add(pr.Name, typeof(string))); //Parallelization not possible since DataTable columns must be in certain order
                ienum.ToList().ForEach(ie => //Parallelization not possible since DataTable rows not synchronized.
                    {
                        List<object> objAdd = new List<object>();
                        ie.GetType().GetProperties().ToList().ForEach(pr => objAdd.Add(ie.GetType().InvokeMember(pr.Name, BindingFlags.GetProperty, null, ie, null))); //Parallelization not possible since DataTable columns must be in certain order
                        dt.Rows.Add(objAdd.ToArray());
                        objAdd.Clear();
                        objAdd = null;
                    });
                //Do something fun with dt
            }
        }
