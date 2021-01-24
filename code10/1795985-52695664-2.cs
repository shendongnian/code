        public static void ModifyCollection<T>(this IEnumerable<T> source, Predicate<T> selectedPredicate,Action<T> selectedAction, Action<T> othersAction=null)
        {
            if (selectedPredicate == null) throw new ArgumentNullException(nameof(selectedPredicate));
            if (selectedAction == null) throw new ArgumentNullException(nameof(selectedAction));
            foreach (var element in source)
            {
                if (selectedPredicate(element))
                {
                    selectedAction(element);
                }
                else
                {
                    othersAction?.Invoke(element);                    
                }
            }
        }
