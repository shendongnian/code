                DateTime PayDate = PaymentDatePicker.Value;  //Payment or Transaction Date 
                DateTime DueDate = PayDate.AddMonths(1);  // due date = Payment date + one month 
                var install = new Instalment();  // object of instalment class/table
             
               install.PaymentDate = PayDate;
               install.NextDueDate = DueDate;
               context.Instalments.Add(install);
               context.SaveChanges();
            }
