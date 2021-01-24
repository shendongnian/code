            ICollection keyCollection = toolTipRegions.Keys;
            string[] keys = new string[keyCollection.Count];
            keyCollection.CopyTo(keys, 0);
            for (int i = 0; i < keys.Length + 1; i++)
            {
                if (i == keys.Length + 1)
                {
                    toolTip.SetToolTip(m_control, tte.text);
                    toolTip.Active = true;
                    oldRegion = rect;
                    toolTipUsed = true;
                    break;
                }
                var entry = toolTipRegions[keys[i]];
                var tte = (ToolTipEntry)entry.Value;
                Rectangle rect = tte.region;
                if (RectangleHitTest(point, rect))
                {
                    sb.Append(tte.text + "\n");
                }
            }
