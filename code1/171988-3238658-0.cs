        private void dataGrid1_AutoGeneratingColumn(object sender,DataGridAutoGeneratingColumnEventArgs e)
        {
                Style style = new Style(typeof(DataGridColumnHeader));
                Trigger trigger = new Trigger();
                trigger.Property = IsMouseOverProperty;
                trigger.Value = true;
                Setter setter = new Setter();
                setter.Property = ToolTipProperty;
                setter.Value = "Your tooltip";
                trigger.Setters.Add(setter);
                style.Triggers.Add(trigger);
                e.Column.HeaderStyle = style;
                
        }
