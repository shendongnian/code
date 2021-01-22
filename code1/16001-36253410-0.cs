	public interface HasMixins {}
	public interface Has<TMixin> : HasMixins
		where TMixin : Mixin {
		TMixin Mixin { get; }
	}
