    /// <summary>
    /// A class for parsing commands inside a tool. Based on Novell Options class (http://www.ndesk.org/Options).
    /// </summary>
    public class CommandOptions
    {
    	private Dictionary<string, Action<string[]>> _actions;
    	private Dictionary<string, Action> _actionsNoParams;
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="CommandOptions"/> class.
    	/// </summary>
    	public CommandOptions()
    	{
    		_actions = new Dictionary<string, Action<string[]>>();
    		_actionsNoParams = new Dictionary<string, Action>();
    	}
    
    	/// <summary>
    	/// Adds a command option and an action to perform when the command is found.
    	/// </summary>
    	/// <param name="name">The name of the command.</param>
    	/// <param name="action">An action delegate</param>
    	/// <returns>The current CommandOptions instance.</returns>
    	public CommandOptions Add(string name, Action action)
    	{
    		_actionsNoParams.Add(name, action);
    		return this;
    	}
    
    	/// <summary>
    	/// Adds a command option and an action (with parameter) to perform when the command is found.
    	/// </summary>
    	/// <param name="name">The name of the command.</param>
    	/// <param name="action">An action delegate that has one parameter - string[] args.</param>
    	/// <returns>The current CommandOptions instance.</returns>
    	public CommandOptions Add(string name, Action<string[]> action)
    	{
    		_actions.Add(name, action);
    		return this;
    	}
    
    	/// <summary>
    	/// Parses the text command and calls any actions associated with the command.
    	/// </summary>
    	/// <param name="command">The text command, e.g "show databases"</param>
    	public bool Parse(string command)
    	{
    		if (command.IndexOf(" ") == -1)
    		{
    			// No params
    			foreach (string key in _actionsNoParams.Keys)
    			{
    				if (command == key)
    				{
    					_actionsNoParams[key].Invoke();
    					return true;
    				}
    			}
    		}
    		else
    		{
    			// Params
    			foreach (string key in _actions.Keys)
    			{
    				if (command.StartsWith(key) && command.Length > key.Length)
    				{
    					
    					string options = command.Substring(key.Length);
    					options = options.Trim();
    					string[] parts = options.Split(' ');
    					_actions[key].Invoke(parts);
    					return true;
    				}
    			}
    		}
    
    		return false;
    	}
    }
