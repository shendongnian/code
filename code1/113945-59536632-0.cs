`
using Microsoft.TeamFoundation.Client;
using MTVC = Microsoft.TeamFoundation.VersionControl.Client;
TfsClientCredentials tfsClientCreds = new TfsClientCredentials(
				new WindowsCredential(System.Net.CredentialCache.DefaultCredentials, new UICredentialsProvider()), true);
TfsTeamProjectCollection tmPrjColl = new TfsTeamProjectCollection(new Uri(TFSServer), tfsClientCreds);
MTVC.VersionControlServer verCtrlSvr = tmPrjColl.GetService<MTVC.VersionControlServer>();
`
