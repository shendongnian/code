`
using Microsoft.TeamFoundation.Client;
using MTVC = Microsoft.TeamFoundation.VersionControl.Client;
using MVSC = Microsoft.VisualStudio.Services.Common;
MVSC.VssCredentials creds = new MVSC.VssCredentials(new MVSC.WindowsCredential(true));
using (TfsTeamProjectCollection tmPrjColl = new TfsTeamProjectCollection(new Uri("<source control URL>"), creds))
{
	MTVC.VersionControlServer verCtrlSvr = tmPrjColl.GetService<MTVC.VersionControlServer>();
	...
}
`
