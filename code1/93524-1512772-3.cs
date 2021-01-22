          public class Field 
            { 
                  public string Prefix {get;set;}
            }
            
            public class FieldCollection : System.Collections.ObjectModel.Collection<Field>
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
    
          public class Form
          {
                  public string Prefix{get;set;}
                  public FieldCollection Fields = new FieldCollection();
          }
  
 
