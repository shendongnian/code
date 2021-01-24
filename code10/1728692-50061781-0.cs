     public static async Task<System.Data.Linq.Table<Equipment>> GetEquipmentTable()
            {           
                    DataClassesDataContext dc = new DataClassesDataContext();
                    return dc.GetTable<Equipment>();            
            }
 
