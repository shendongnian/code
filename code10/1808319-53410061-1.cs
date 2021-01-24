    public class AdMobImplementation : RewardBasedVideoAdDelegate
        {
            public AdMobImplementation()
            {
                RewardBasedVideoAd.SharedInstance.Delegate = this;
    RewardBasedVideoAd.SharedInstance.LoadRequest(Request.GetDefaultRequest(), "ca-app-pub-3940256099942544/1712485313");
                }
            public override void DidRewardUser(RewardBasedVideoAd rewardBasedVideoAd, AdReward reward)
            {
                Console.WriteLine("rewarded");
            }
    
         public override void DidFailToLoad(RewardBasedVideoAd rewardBasedVideoAd, NSError error)
            {
                Console.WriteLine($"Reward based video ad failed to load with error:{error.LocalizedDescription}.");
            }
    
            public override void DidReceiveAd(RewardBasedVideoAd rewardBasedVideoAd)
            {
                Console.WriteLine("Reward based video ad is received.");
            }
    
            public override void DidOpen(RewardBasedVideoAd rewardBasedVideoAd)
            {
                Console.WriteLine("Opened reward based video ad.");
            }
    
            public override void DidStartPlaying(RewardBasedVideoAd rewardBasedVideoAd)
            {
                Console.WriteLine("Reward based video ad started playing.");
            }
    
            public override void DidClose(RewardBasedVideoAd rewardBasedVideoAd)
            {
                Console.WriteLine("Reward based video ad is closed.");
            }
    
            public override void WillLeaveApplication(RewardBasedVideoAd rewardBasedVideoAd)
            {
                Console.WriteLine("Reward based video ad will leave application.");
            }
    }
