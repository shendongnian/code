    interface IGameObjectModel {
    	void Shoot();
    		:
    }
    
    class GameObject<TModel> where TModel:IGameObjectModel {
    	public TModel Model;
    	public GameObject(TModel model) {
    		Model = model;
    	}
    	public void Shoot() {
    		Model.Shoot();
    	}
    		:
    }
    
    class MissleModel : IGameObjectModel {
    	public void Shoot() {
    		:
    	}	
    }
