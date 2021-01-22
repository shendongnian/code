        public void InspectList(IList<int> values)
        {
            if(values != null)
            {
                string format = "Element At {0}";
                foreach(int i in values)
                {
                    Log(string.Format(format, i));
                }
            }   
        }
