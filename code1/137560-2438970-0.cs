        public void InspectList(IList<int> values)
        {
            if(values != null)
            {
                foreach(int i in values)
                {
                    Log(string.Format("Element At {0}", i));
                }
            }   
        }
