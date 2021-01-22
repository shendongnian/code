    private static List<LabelType> ConvertControlCollectionToList(Control customContainer)
    {
        LabelTypeList.LabelProps.Clear();
        foreach (Control c in customContainer.Controls)
        {
            LabelType lt = new LabelType();
            LabelTypeList.LabelProps.Add(lt);
            lt.Name = c.Name;
            lt.Top = c.Top;
            lt.Left = c.Left;
            lt.Height = c.Height;
            lt.Width = c.Width;
            lt.Font = c.Font;
            lt.Text = c.Text;
            YourUserControlType uc = c as YourUserControlType;
            if(uc != null)
            {
                lt.DataColumn = uc.DataColumn;
                lt.Rotation = uc.Rotation;
            }
        }
        return LabelTypeList.LabelProps;
    }
