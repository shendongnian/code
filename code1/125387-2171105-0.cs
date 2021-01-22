    public class MultiClass : Class {
        ...
        public MultiClass(params Class[] classes) {
            this.classes = classes;
        }
        public IEnumerable<Ability> GetAbilities() {
            return this.classes.SelectMany(с => c.GetAbilities());
        }
        ...
    }
