        public IEnumerable<AMAPnr.Airplane> getItems(Planes)
        {
            foreach (AMAPnr.Airplane airElement in Planes)
            {
                yield return airElement;
            }
            yield break;
        }
