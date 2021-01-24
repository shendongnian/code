    public class Category: IEquatable<Category>
    {
       string name;
       int id;
    public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Category objAsCategory = obj as Category;
            if (objAsCategory == null) return false;
            else return Equals(objAsCategory);
        }
    public bool Equals(Category other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    
