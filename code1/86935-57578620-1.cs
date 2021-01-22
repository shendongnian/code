    SelectListItem firstItem = new SelectListItem();
    int selectListCount = -1;
    if (source != null && source.Items != null)
    {
        System.Collections.IEnumerator cenum = source.Items.GetEnumerator();
        while (cenum.MoveNext())
        {
            if (selectListCount == -1)
            {
                selectListCount = 0;
            }
            selectListCount += 1;
            category = (Category)cenum.Current;
            source.SetSelectedValue(category.Name);
            break;
        }
        if (selectListCount > 0)
        {
            foreach (SelectListItem item in source.Items)
            {
                if (item.Value == cenum.Current.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }
        }
    }
    return source;
