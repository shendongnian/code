        public object Clone()
        {
            OrderItem newOrderItem = new OrderItem();
            ...
            newOrderItem._exactPlacements.AddRange(SpotPlacement.CloneList(_exactPlacements));
            ...
            return newOrderItem;
        }
