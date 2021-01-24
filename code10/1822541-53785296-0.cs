    public class Game : MonoBehaviour
    {
    	public InputField console;
    }
    public class Chat : MonoBehaviour
    {
    	public Game game;
    	string text = game.console.text;
    }
