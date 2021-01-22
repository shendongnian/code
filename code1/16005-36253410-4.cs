	public static class MixinUtils {
		public static TMixin Mixout<TMixin>(this Has<TMixin> what)
			where TMixin : Mixin {
			return what.Mixin;
		}
	}
