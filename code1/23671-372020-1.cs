            for (int index = 0; index < list.Items.Count; index++)
            {
                if (list.ClientRectangle.IntersectsWith(item.GetBounds(ItemBoundsPortion.Entire)))
                {
                    // Add to the list to get data.
                }
                else
                {
                    // We got them all.
                    break;
                }
            }
