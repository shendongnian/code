    private static int FindLabel(AxisLabelsItems items, string labelText)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Text == labelText)
                {
                    return i;
                }
            }
            return -1;
        }
