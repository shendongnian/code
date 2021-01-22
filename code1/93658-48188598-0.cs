    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace PracticeApp
    {
        class PracticeApp
        {        
            public void InsertRecord(string Name, string Dept) {
                LinqToSQLDataContext LTDT = new LinqToSQLDataContext();
                LINQTOSQL0 L0 = new LINQTOSQL0 { NAME = Name, DEPARTMENT = Dept };
                LTDT.LINQTOSQL0s.InsertOnSubmit(L0);
                LTDT.SubmitChanges();
            }
    
            public void UpdateRecord(int ID, string Name, string Dept)
            {
                LinqToSQLDataContext LTDT = new LinqToSQLDataContext();
                LINQTOSQL0 L0 = (from item in LTDT.LINQTOSQL0s where item.ID == ID select item).FirstOrDefault();
                L0.NAME = Name;
                L0.DEPARTMENT = Dept;
                LTDT.SubmitChanges();
            }
    
            public void DeleteRecord(int ID)
            {
                LinqToSQLDataContext LTDT = new LinqToSQLDataContext();
                LINQTOSQL0 L0;
                if (ID != 0)
                {
                    L0 = (from item in LTDT.LINQTOSQL0s where item.ID == ID select item).FirstOrDefault();
                    LTDT.LINQTOSQL0s.DeleteOnSubmit(L0);
                }
                else
                {
                    IEnumerable<LINQTOSQL0> Data = from item in LTDT.LINQTOSQL0s where item.ID !=0 select item;
                    LTDT.LINQTOSQL0s.DeleteAllOnSubmit(Data);
                }           
                LTDT.SubmitChanges();
            }
                                  
            static void Main(string[] args) {
                Console.Write("* Enter Comma Separated Values to Insert Records\n* To Delete a Record Enter 'Delete' or To Update the Record Enter 'Update' Then Enter the Values\n* Dont Pass ID While Inserting Record.\n* To Delete All Records Pass 0 as Parameter for Delete.\n");
                var message = "Successfully Completed";
                try
                {
                    PracticeApp pa = new PracticeApp();
                    var enteredValue = Console.ReadLine();                
                    if (Regex.Split(enteredValue, ",")[0] == "Delete") 
                    {
                        Console.Write("Delete Operation in Progress...\n");
                        pa.DeleteRecord(Int32.Parse(Regex.Split(enteredValue, ",")[1]));
                    }
                    else if (Regex.Split(enteredValue, ",")[0] == "Update")
                    {
                        Console.Write("Update Operation in Progress...\n");
                        pa.UpdateRecord(Int32.Parse(Regex.Split(enteredValue, ",")[1]), Regex.Split(enteredValue, ",")[2], Regex.Split(enteredValue, ",")[3]);
                    }
                    else
                    {
                        Console.Write("Insert Operation in Progress...\n");
                        pa.InsertRecord(Regex.Split(enteredValue, ",")[0], Regex.Split(enteredValue, ",")[1]);
                    }                                
                }
                catch (Exception ex)
                {
                    message = ex.ToString();
                }
                Console.Write(message);            
                Console.ReadLine();                        
            }
        }
    }
