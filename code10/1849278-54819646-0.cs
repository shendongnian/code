cs
[Guid("9C6B4CB0-23F8-49CC-A3ED-45A55000A6D2")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] // <-- need this
public interface IDxDiagProvider
{
    void Initialize(ref DXDIAG_INIT_PARAMS pParams);
    void GetRootContainer(out IDxDiagContainer ppInstance);
}
[Guid("7D0F462F-4064-4862-BC7F-933E5058C10F")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] // <-- need this
public interface IDxDiagContainer
{
    void EnumChildContainerNames(uint dwIndex, string pwszContainer, uint cchContainer);
    void EnumPropNames(uint dwIndex, string pwszPropName, uint cchPropName);
    void GetChildContainer(string pwszContainer, out IDxDiagContainer ppInstance);
    void GetNumberOfChildContainers(ref uint pdwCount);
    void GetNumberOfProps(out uint pdwCount);
    void GetProp(string pwszPropName, out IntPtr pvarProp);
}
