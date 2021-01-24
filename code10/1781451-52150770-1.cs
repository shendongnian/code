    public class TilePrototype {
	public static Dictionary<int, TilePrototype> tilePrototypeDictionary = new Dictionary<int, TilePrototype>();
	public static void registerPrototype(int id, TilePrototype tp){
		tp.id = id;
		tilePrototypeDictionary.Add(id, tp);
	}
	public static bool registered = false;
	public static void registerAll(){
		if( registered ) return;
		registerPrototype(0, Void.instance);
		registerPrototype(1, Air.instance);
		registerPrototype(2, Floor.instance);
		registerPrototype(3, Wall.instance);
    (...)
