    public List<Control> FindSelects( Control control, List<Control> controls )
    {
         if (control is DropDownList or control is HtmlSelect)
         {
              controls.Add( control );
         }
         else if (control.HasControls)
         {
              foreach (var subcontrol in control.Controls)
              {
                   controls = FindSelects( subcontrol, controls );
              }
         }
         return controls;
    }
