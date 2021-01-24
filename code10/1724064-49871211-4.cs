    public class GrenadeSkill: BaseSkill{
        
        public override void Execute(JsonObject json){
           float timeStamp = (int)json["timestamp"];        
           Vector3 targetPosition = (Vector3)json["position"];
           // ...
           // and you grenade logic
        }
    }
