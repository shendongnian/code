        enum DaysCollection
        {
         sunday,
         Monday,
         Tuesday,
         Wednesday,
         Thursday,
         Friday,
         Saturday
        }
        public bool isDefined(string[] arr,object obj)
        {
            bool result=false;
            foreach (string enu in arr)
            {
                  result = string.Compare(enu, obj.ToString(), true) == 0;
                  if (result)
                      break;
                
            }
            return result;
           
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            object obj = "wednesday";
            string[] arr = Enum.GetNames(typeof(DaysCollection)).ToArray();
            isDefined(arr,obj);
        }
