// Generic scene resolver is abstract and requires
// to implement enum to index conversion
public abstract class SceneResolver<TSceneTypeEnum> : ScriptableObject
    where TSceneTypeEnum : Enum
{
    protected ScenePicker[] Scenes;
    public string GetScenePath ( TSceneTypeEnum sceneType )
    {
        return Scenes[SceneTypeToIndex( sceneType )].Path;
    }
    protected abstract int SceneTypeToIndex ( TSceneTypeEnum sceneType );
}
// Here is some enum for non-generic class
public enum SceneType
{
}
// Some non-generic implementation
public class SceneResolver : SceneResolver<SceneType>
{
    protected override int SceneTypeToIndex ( SceneType sceneType )
    {
        return ( int )sceneType;
    }
}
I tested boxing vs. virtual method and got 10x speed up for virtual method approach on macOS for both Mono and IL2CPP targets. 
