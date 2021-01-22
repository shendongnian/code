      public class Field 
        { 
              public string Prefix {get;set;}
        }
        
        public class FieldCollection : Collection<Field>
        {
              private Form form;
        
             public FieldCollection(Form f)
             {
                     form = f;
             }
        
             
             protected override void InsertItem(int index, Field item)
             {
                     base.InsertItem(index, item);
                     item.Prefix = form.Prefix;
             }
        }
  
 
