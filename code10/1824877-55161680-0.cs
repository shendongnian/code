           if (intentRequest.Intent.Slots.TryGetValue("date", out var dateSlot))
                {
                    if (!string.IsNullOrEmpty(dateSlot.Value))
                    {
                       //Slot value
                    }
                }
