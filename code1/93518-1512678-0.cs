    Form frm = new Form();
    frm.AddField(new Field());    
    
    
    class Form
            {
                private List<Field> fields;
                public string Prefix { get; set; }
                public string formName;
                public string prefix;
        
                public void AddField(Field field)
                {
                    field.RenderHTML(this.formName,this.prefix);
                    fields.Add(field);
                }
            }
        
            class Field
            {
                public void RenderHTML(string prefix,string id)
                {
                    // render html element with ID attribute
                    // prefixed with the parent form's Prefix property
                }
            }
