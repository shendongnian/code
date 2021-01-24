    public class AttributNode
    {
        public Attribut       ATTRIBUT        { get; set; }
        public AttributNode[] CHILDREN        { get; set; }
        public void Sort() {
            foreach (Attribut child in CHILDREN) {
                child.Sort();
            }
            Array.Sort(
                CHILDREN,
                (x, y) => x.ATTRIBUT.ATT_LIBELLE.CompareTo(y.ATTRIBUT.ATT_LIBELLE));
        }
        IEnumerator<Attribut> Flatten()
        {
            yield return ATTRIBUT;
            foreach (IEnumerable<Attribut> items in CHILDREN.Select((c) => c.Flatten()))
            {
                foreach (Attribut item in items) {
                    yield return item;
                }
            }
        }
    }
