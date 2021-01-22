        public static bool compare(this FileInfo F1,FileInfo F2,string propertyName)
        {
            try
            {
                System.Reflection.PropertyInfo p1 = F1.GetType().GetProperty(propertyName);
                System.Reflection.PropertyInfo p2 = F2.GetType().GetProperty(propertyName);
                
                    if (p1.GetValue(F1, null) == p2.GetValue(F1, null))
                    {
                        return true;
                    }
               
            }
            catch (Exception ex)
            {
                return false;
            }
            
            return false;
        }
