    public static Tween.TweenExecuter To<T>(this Ref<T> thisArg, T to, float time, EasingType easing = EasingType.Linear, TweenType type = TweenType.Simple, Func<bool> trigger = null, Action callback = null) where T : struct
    {
  		Tween.TweenElement<T> tween = new Tween.TweenElement<T>() 
		{
			from = thisArg,
			Setter = x => thisArg.Value = x,
			to = to,
			time = time,
			easing = easing,
			type = type,
			Trigger = trigger,
			Callback = callback
		};
        return new Tween.TweenExecuter(tween);
	}
