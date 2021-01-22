    protected string GetColor(object container)
            {
                int ordinal = 0;
                try
                {
                    ordinal = int.Parse(DataBinder.Eval(container, "DataItemIndex").ToString());
                }
                catch (Exception)
                {
                    ordinal = int.Parse(DataBinder.Eval(container, "ItemIndex").ToString());
                }
                return (ordinal % 2) == 0 ? "Row" : "Alternate Row";
            }
