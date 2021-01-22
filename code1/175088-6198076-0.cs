    var actionCodes = pps.GetAllActionCodes();
    if (actionCodes != null)
    {
        var actionCodesNew = (from c in actionCodes
                                    select new
                                    {
                                        c.Code,
                                        c.Text,
                                        CodeAndDesc = string.Format("{0} {1}", c.Code, c.Text).Trim()
                                    }).ToArray();
                comboBox.Items.AddRange(actionCodesNew);
                comboBox.DisplayMember = "CodeAndDesc";
            }
    }
