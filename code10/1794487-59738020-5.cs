    public class StopLottieAnimationTriggerAction : TriggerAction<AnimationView>
    {
    	protected override void Invoke(AnimationView sender)
    	{
    		sender.Progress = 0;
    		sender.Pause();
    	}
    }
