    public class GameManager {
    	public void AddTile(Tile t, Tile.IManagerHook m) {
    		m.SomeProperty = "set from manager";
    	}
    }
    
    public class Tile
    {
    	public object SomeProperty { get; private set; }
    
    	public Tile(GameManager manager) {
    		manager.AddTile(this, new ManagerHook(this));
    	}
    	
    	public interface IManagerHook {
    		object SomeProperty {get; set;}
    	}
    	
    	
    	private class ManagerHook : IManagerHook {
    		private Tile _tile;
    		public ManagerHook(Tile t) {
    			_tile = t;
    		}
    		
    		public object SomeProperty {
    			get{ return  _tile.SomeProperty;}
    			set { _tile.SomeProperty = value; }			
    		}
    	}
    }
