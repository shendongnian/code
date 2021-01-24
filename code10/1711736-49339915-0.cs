    public interface IItem {
        float Weight { get; set; }
    }
    
    public interface IGrabItem : IItem {
        void Grab();
    }
    
    public interface IDropItem : IItem {
        void Drop();
    }
    
    public interface IUseItem : IItem {
        void Use();
    }
    
    public class MedKit : MonoBehaviour, IGrabItem, IUseItem {
    	[SerializeField]
    	float weight;
    	public float Weight {
    		get { return weight; }
    		set { weight = value; }
    	}
    	public void Grab() {
    		//Your code
    	}
    	public void Use() {
    		//Your code
    	}
    }
