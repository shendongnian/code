    public class StartLottieAnimationTriggerAction : TriggerAction<AnimationView>
    {
    	protected override void Invoke(AnimationView sender)
    	{
    		sender.Play();
    	}
    }
