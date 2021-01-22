    // This Class is need to override StudioOnlineCommonHelper Methods in a branch
    public class StudioOnlineCommonHelper : StudioOnlineCore.StudioOnlineCommonHelper
    {
        //
        public static new void DoBusinessRulesChecks(Page page)
        {
            StudioOnlineCore.StudioOnlineCommonHelper.DoBusinessRulesChecks(page);
        }
    }
}
