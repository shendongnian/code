      public class FieldEventArgs : EventArgs
        {
            public Field Field { get; private set; }
            public FieldEventArgs(Field field)
            {
                Field = field;
            }
        }
    
        public partial class Field
        {
            public event EventHandler<FieldEventArgs> OnBeforeRender;
            public string Prefix { get;  set; }
             public void Render()
             {
                 if (OnBeforeRender != null)
                 {
                     OnBeforeRender(this, new FieldEventArgs(this));
                     // render html or do whatever
                 }
             }
        }
    
        public class Form
        {
            private List<Field> Fields;
            public string Prefix { get; set; }
    
            public void AddField(Field field)
            {
                field.OnBeforeRender += Field_OnBeforeRender;
                Fields.Add(field);
            }
    
            void Field_OnBeforeRender(object sender, FieldEventArgs e)
            {
                e.Field.Prefix = Prefix;
            }
        }
