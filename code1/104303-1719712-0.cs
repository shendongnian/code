    private void RemoveInternalC1ComboReferenceListHack(C1Combo combo)
        {
            var result = typeof(C1Combo).GetField("_dropDownList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(combo);
            var result2 = result.GetType().GetField("c", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(result);
            var result3 = result2.GetType().GetField("r", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(result2);
            var result4 = result3.GetType().GetField("b", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(result3);
            ((System.Collections.Generic.List<Control>)result4).Clear();
        }
