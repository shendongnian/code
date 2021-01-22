    public abstract class Person
    {
    }
    public class Parent : Person
    {
        private HashSet<ParentChildRelationship> _children = 
            new HashSet<ParentChildRelationship>();
        public virtual IEnumerable<ParentChildRelationship> Children
        {
            get { return this._children; }
        }
        public virtual void AddChild(Child child, RelationshipKind relationshipKind)
        {
            var relationship = new ParentChildRelationship()
            {
                Parent = this,
                Child = child,
                RelationshipKind = relationshipKind
            };
            this._children.Add(relationship);
            child.AddParent(relationship);
        }
    }
    public class Child : Person
    {
        private HashSet<ParentChildRelationship> _parents = 
            new HashSet<ParentChildRelationship>();
        public virtual IEnumerable<ParentChildRelationship> Parents
        {
            get { return this._parents; }
        }
        internal virtual void AddParent(ParentChildRelationship relationship)
        {
            this._parents.Add(relationship);
        }
    }
    public class ParentChildRelationship
    {
        public virtual Parent Parent { get; protected internal set; }
        public virtual Child Child { get; protected internal set; }
        public virtual RelationshipKind RelationshipKind { get; set; }
    }
    public enum RelationshipKind
    {
        Unknown,
        Natural,
        Adoptive,
        Surrogate,
        StepParent
    }
