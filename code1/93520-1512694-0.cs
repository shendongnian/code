      public class Form
      {        
         private Fields fields = new Fields(this);
         public string Prefix { get; set; }       
         public void AddField(Field field)
         {   
          field.Form = this;
          fields.Add(field);
         }
      }
    
      public class Fields: List<Field>
      {
          public Form Form { get; set; }
          public Fields(Form form)
          { Form = form; }
          public void Add(Field fleld)
          {
              field.Form = Form;
              Add(field);
          }
      }
