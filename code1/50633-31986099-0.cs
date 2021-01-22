            public Control GetFirstTabindexControl(Control container)
            {
                Control res= container.GetNextControl(container, true);
                if (!res.CanSelect)
                    res= GetFirstTabindexControl(res);
                return res;
            }
