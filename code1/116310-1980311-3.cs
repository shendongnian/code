     using System;
     using System.Web.UI.WebControls;
     using System.Web.UI;
     using System.ComponentModel;
     using System.Web;
     using System.Collections.Specialized;
    namespace IDVCode.GridViews
    {
    public class DropDownField : BoundField
    {
        #region fields
        private string _listDataSourceID;
        private string _listDataMember;
        private string _listDataTextField;
        private string _listDataValueField;
        #endregion 
        #region eventHandler
        protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
        {
                DropDownList dropDownList = new DropDownList();
                dropDownList.ToolTip = HeaderText;
                dropDownList.DataSourceID = ListDataSourceID;
                dropDownList.DataMember = ListDataMember;
                dropDownList.DataTextField = ListDataTextField;
                dropDownList.DataValueField = ListDataValueField;
                dropDownList.Enabled = !ReadOnly;
                cell.Controls.Add(dropDownList);
                if (rowState == DataControlRowState.Normal || rowState == DataControlRowState.Alternate || ReadOnly)
                {
                    dropDownList.Enabled = false;
                }
                if (DataField.Length != 0) // && ((rowState & DataControlRowState.Edit) != DataControlRowState.Normal))
                {
                    dropDownList.DataBound += new EventHandler(OnDataBindField);
                }
           }
        protected override void OnDataBindField(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Control namingContainer = control.NamingContainer;
            object dataValue = GetValue(namingContainer);
            bool encode = (SupportsHtmlEncode && HtmlEncode) && (control is TableCell);
            string str = FormatDataValue(dataValue, encode);
            if (control is TableCell)
            {
                if (str.Length == 0)
                {
                    str = "&nbsp;";
                }
                ((TableCell)control).Text = str;
            }
            else
            {
                if (!(control is DropDownList))
                {
                    throw new HttpException("BoundField_WrongControlType");
                }
                if (((DropDownList)control).Items.Count > 0)    // Don't call selectedValue if empty
                {
                    if (dataValue != null)
                    {
                        DropDownList dropDownList = (DropDownList)control;
                        
                        ListItem item = null;
                        if (FindBy == SetSelectedValueBy.Value)
                        {
                            item = dropDownList.Items.FindByValue(dataValue.ToString());
                        }
                        else
                        {
                            item = dropDownList.Items.FindByText(dataValue.ToString());
                        }
                        if (item != null)
                            dropDownList.Text = item.Value;
                        else
                        {
                            ListItem defaultItem = dropDownList.Items.FindByText(DefaultValueText);
                            if (defaultItem != null)
                                dropDownList.SelectedValue = defaultItem.Value;
                        }
                    }
                }
            }
        }
        public override void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell,
            DataControlRowState rowState, bool includeReadOnly)
        {
            Control control = null;
            string dataField = DataField;
            object text = null;
            string nullDisplayText = NullDisplayText;
            if (((rowState & DataControlRowState.Insert) == DataControlRowState.Normal) || InsertVisible)
            {
                if (cell.Controls.Count > 0)
                {
                    control = cell.Controls[0];
                    DropDownList box = control as DropDownList;
                    if (box != null)
                    {
                        text = box.SelectedValue;
                    }
                }
                else if (includeReadOnly)
                {
                    string s = cell.Text;
                    if (s == "&nbsp;")
                    {
                        text = string.Empty;
                    }
                    else if (SupportsHtmlEncode && HtmlEncode)
                    {
                        text = HttpUtility.HtmlDecode(s);
                    }
                    else
                    {
                        text = s;
                    }
                }
                if (text != null)
                {
                    if (((text is string) && (((string)text).Length == 0)) && ConvertEmptyStringToNull)
                    {
                        text = null;
                    }
                    if (((text is string) && (((string)text) == nullDisplayText)) && (nullDisplayText.Length > 0))
                    {
                        text = null;
                    }
                    if (dictionary.Contains(dataField))
                    {
                        dictionary[dataField] = text;
                    }
                    else
                    {
                        dictionary.Add(dataField, text);
                    }
                }
            }
        }
        #endregion
        #region Properties
        
        public virtual string ListDataSourceID
        {
            get
            {
                if (_listDataSourceID == null)
                {
                    object stateBag = ViewState["ListDataSourceID"];
                    if (stateBag != null)
                    {
                        _listDataSourceID = (string)stateBag;
                    }
                    else
                    {
                        _listDataSourceID = string.Empty;
                    }
                }
                return _listDataSourceID;
            }
            set
            {
                if (!object.Equals(value, ViewState["ListDataSourceID"]))
                {
                    ViewState["ListDataSourceID"] = value;
                    _listDataSourceID = value;
                    OnFieldChanged();
                }
            }
        }
        
        public virtual string ListDataMember
        {
            get
            {
                if (_listDataMember == null)
                {
                    object stateBag = ViewState["ListDataMember"];
                    if (stateBag != null)
                    {
                        _listDataMember = (string)stateBag;
                    }
                    else
                    {
                        _listDataMember = string.Empty;
                    }
                }
                return _listDataMember;
            }
            set
            {
                if (!object.Equals(value, ViewState["ListDataMember"]))
                {
                    ViewState["ListDataMember"] = value;
                    _listDataMember = value;
                    OnFieldChanged();
                }
            }
        }
        
        public virtual string ListDataTextField
        {
            get
            {
                if (_listDataTextField == null)
                {
                    object stateBag = ViewState["ListDataTextField"];
                    if (stateBag != null)
                    {
                        _listDataTextField = (string)stateBag;
                    }
                    else
                    {
                        _listDataTextField = string.Empty;
                    }
                }
                return _listDataTextField;
            }
            set
            {
                if (!object.Equals(value, ViewState["ListDataTextField"]))
                {
                    ViewState["ListDataTextField"] = value;
                    _listDataTextField = value;
                    OnFieldChanged();
                }
            }
        }
        
        public virtual string ListDataValueField
        {
            get
            {
                if (_listDataValueField == null)
                {
                    object stateBag = ViewState["ListDataValueField"];
                    if (stateBag != null)
                    {
                        _listDataValueField = (string)stateBag;
                    }
                    else
                    {
                        _listDataValueField = string.Empty;
                    }
                }
                return _listDataValueField;
            }
            set
            {
                if (!object.Equals(value, ViewState["ListDataValueField"]))
                {
                    ViewState["ListDataValueField"] = value;
                    _listDataValueField = value;
                    OnFieldChanged();
                }
            }
        }
        [Description("Sets a default value if applicable")]
        [Category("Appearance")]
        public string DefaultValueText
        {
            get
            {
                object val = ViewState["DefaultValueText"];
                if (val != null)
                {
                    return (string)val;
                }
                return (string.Empty);
            }
            set
            {
                ViewState["DefaultValueText"] = value;
            }
        }
        
        [Description("Defines how the SelectedValue is set")]
        [Category("Data")]
        [DefaultValue(SetSelectedValueBy.Value)]
        public SetSelectedValueBy FindBy
        {
            get
            {
                object val = ViewState["SetSelectedValueBy"];
                return val != null ? (SetSelectedValueBy) val : SetSelectedValueBy.Value;
            }
            set
            {
                ViewState["SetSelectedValueBy"] = value;
            }
        }
        public enum SetSelectedValueBy
        {
            Text,
            Value
        }
        #endregion
    }
