	internal static class CommandHelper {
		internal static Command createCommand(this Dictionary<string, CommandVO?> d, string name) {
			if (!d.ContainsKey(name)) return null;
			return Activator.CreateInstance(d[name]?.commandClass) as Command;
		}
	}
