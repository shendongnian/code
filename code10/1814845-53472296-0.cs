    public class Scenes
	{
		public static string[,] scenes = new string[,]{
			{"first_level", "scene-1-name"},
			{"level_2", "scene-2-name"},
			{"level_3", "factory-level"},
			{"level_4", "scene-4-name"},
			{"level_5", "jungle"},
		};
		public static string GetSceneNameByToken(string token)
		{
			for (var i = 0; i < scenes.GetLength(0); i++)
				if (scenes[i, 0] == token)
					return scenes[i, 1];
			return null;
		}
	}
