        public class DropDownBoundField : BoundField
    {
        private bool _suppressPropertyThrows;
        protected override void CopyProperties(DataControlField newField)
        {
            ((DropDownBoundField)newField).Text = this.Text;
            this._suppressPropertyThrows = true;
            ((DropDownBoundField)newField)._suppressPropertyThrows = true;
            base.CopyProperties(newField);
            this._suppressPropertyThrows = false;
            ((DropDownBoundField)newField)._suppressPropertyThrows = false;
        }
        protected override DataControlField CreateField()
        {
            return new DropDownBoundField();
        }
        public override void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell,
            DataControlRowState rowState, bool includeReadOnly)
        {
            string dataField = DataField;
            object obj2 = null;
            // object obj3 = null;
            if (cell.Controls.Count > 0)
            {
                // Get column editor of type DropDownList of current cell 
                Control control = cell.Controls[0];
                DropDownList dropDownList = control as DropDownList;
                if ((dropDownList != null) && (includeReadOnly || dropDownList.Enabled))
                {
                    obj2 = dropDownList.Text;
                }
            }
            if (obj2 != null)
            {
                if (dictionary.Contains(dataField))
                {
                    dictionary[dataField] = obj2;
                }
                else
                {
                    //put both text and value into the dictionary
                    dictionary.Add(dataField, obj2);
                }
            }
        }
        protected override object GetDesignTimeValue()
        {
            return true;
        }
        protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
        {
            Control cellControl = null;
            if ((((rowState & DataControlRowState.Edit) != DataControlRowState.Normal) && !this.ReadOnly)
                || ((rowState & DataControlRowState.Insert) != DataControlRowState.Normal))
            {
                // If data cell is in edit mode, create DropDownList editor for this cell
                // and set data properties.
                DropDownList dropDownList = new DropDownList();
                dropDownList.AppendDataBoundItems = true;
                dropDownList.Items.Add(DefaultValueText);
                dropDownList.DataSource = this.GetDataSource();
                dropDownList.DataMember = this.BusinessObjectName;
                dropDownList.DataTextField = this.DataTextField;
                dropDownList.DataValueField = this.DataValueField;
                dropDownList.ToolTip = this.HeaderText;
                cell.Controls.Add(dropDownList);
                //dropDownList.DataBind();
                             
                // if in edit mode, prepare dropdown for binding
                if ((this.DataField.Length != 0) && ((rowState & DataControlRowState.Edit) != DataControlRowState.Normal))
                {
                    dropDownList.DataBound += new EventHandler(this.OnDataBound); // attach to event for item selection
                }
            }
            //else if (this.DataField.Length != 0)    // if in read only mode, prepare cell for binding
            //{
            //    cellControl = cell;
            //}
            //if ((cellControl != null) && base.Visible)
            //{
            //    cellControl.DataBinding += new EventHandler(this.OnDataBindField);
            //}
        }
        protected void OnDataBound(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Control namingContainer = control.NamingContainer;
            object dataValue = this.GetValue(namingContainer);
            bool encode = (this.SupportsHtmlEncode && this.HtmlEncode) && (control is TableCell);
            string str = this.FormatDataValue(dataValue, encode);
            if (control is TableCell)
            {
                if (str.Length == 0) str = "&nbsp;";
                ((TableCell)control).Text = str;
            }
            else
            {
                //If data cell is in edit mode, set selected value of DropDownList 
                if (dataValue != null)
                {
                    DropDownList dropDownList = (DropDownList)control;
                    ListItem item = dropDownList.Items.FindByText(dataValue.ToString());
                    if (item != null) 
                        dropDownList.Text = item.Value;
                    else
                    {
                        ListItem defaultItem = dropDownList.Items.FindByText(DefaultValueText);
                        if (defaultItem != null) 
                            dropDownList.Text = DefaultValueText;
                    }
                }
            }
        }
        public object GetDataSource()
        {
            Type businessObjectType = BuildManager.GetType(this.BusinessObjectName, true);
            object bObject = Activator.CreateInstance(businessObjectType);
            return businessObjectType.GetMethod(this.SelectMethod).Invoke(bObject, null);
        }
        #region fields
        public string BusinessObjectName
        {
            get
            {
                object val = this.ViewState["BusinessObjectName"];
                if (val != null)
                {
                    return (string)val;
                }
                return (string.Empty);
            }
            set
            {
                this.ViewState["BusinessObjectName"] = value;
            }
        }
        public string SelectMethod
        {
            get
            {
                object val = this.ViewState["SelectMethod"];
                if (val != null)
                {
                    return (string)val;
                }
                return (string.Empty);
            }
            set
            {
                this.ViewState["SelectMethod"] = value;
            }
        }
        public string DataTextField
        {
            get
            {
                object val = this.ViewState["DataTextField"];
                if (val != null)
                {
                    return (string)val;
                }
                return (string.Empty);
            }
            set
            {
                this.ViewState["DataTextField"] = value;
            }
        }
        public string DataValueField
        {
            get
            {
                object val = this.ViewState["DataValueField"];
                if (val != null)
                {
                    return (string)val;
                }
                return (string.Empty);
            }
            set
            {
                this.ViewState["DataValueField"] = value;
            }
        }
        public string DefaultValueText
        {
            get
            {
                object val = this.ViewState["DefaultValueText"];
                if (val != null)
                {
                    return (string)val;
                }
                return (string.Empty);
            }
            set
            {
                this.ViewState["DefaultValueText"] = value;
            }
        }
        [Localizable(true), DefaultValue("")]
        public virtual string Text
        {
            get
            {
                object obj2 = base.ViewState["Text"];
                if (obj2 != null)
                {
                    return (string)obj2;
                }
                return string.Empty;
            }
            set
            {
                if (!object.Equals(value, base.ViewState["Text"]))
                {
                    base.ViewState["Text"] = value;
                    this.OnFieldChanged();
                }
            }
        }
        #endregion fields
    }
