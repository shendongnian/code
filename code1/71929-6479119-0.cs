        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Runtime.Serialization;
        using System.Reflection;
        namespace RD.Runtime
        {
            [Serializable]
            public struct RuntimeDelegate
            {
                private static class RuntimeDelegateUtility
                {
                    public static BindingFlags GetSuggestedBindingsForMethod(MethodInfo method)
                    {
                        BindingFlags SuggestedBinding = BindingFlags.Default;
                        if (method.IsStatic)
                            SuggestedBinding |= BindingFlags.Static;
                        else
                            SuggestedBinding |= BindingFlags.Instance;
                        if (method.IsPublic)
                            SuggestedBinding |= BindingFlags.Public;
                        else
                            SuggestedBinding |= BindingFlags.NonPublic;
                        return SuggestedBinding;
                    }
                    public static Delegate Create(RuntimeDelegate link, Object linkObject)
                    {
                        AssemblyName ObjectAssemblyName = null;
                        AssemblyName DelegateAssemblyName = null;
                        Assembly ObjectAssembly = null;
                        Assembly DelegateAssembly = null;
                        Type ObjectType = null;
                        Type DelegateType = null;
                        MethodInfo TargetMethodInformation = null;
                        #region Get Assembly Names
                        ObjectAssemblyName = GetAssemblyName(link.ObjectSource);
                        DelegateAssemblyName = GetAssemblyName(link.DelegateSource);
                        #endregion
                        #region Load Assemblys
                        ObjectAssembly = LoadAssembly(ObjectAssemblyName);
                        DelegateAssembly = LoadAssembly(DelegateAssemblyName);
                        #endregion
                        #region Get Object Types
                        ObjectType = GetTypeFromAssembly(link.ObjectFullName, ObjectAssembly);
                        DelegateType = GetTypeFromAssembly(link.DelegateFullName, DelegateAssembly);
                        #endregion
                        #region Get Method
                        TargetMethodInformation = ObjectType.GetMethod(link.ObjectMethodName, link.SuggestedBinding);
                        #endregion
                        #region Create Delegate
                        return CreateDelegateFrom(linkObject, ObjectType, DelegateType, TargetMethodInformation);
                        #endregion
                    }
                    private static AssemblyName GetAssemblyName(string source)
                    {
                        return GetAssemblyName(source, source.ToUpper().EndsWith(".DLL") || source.ToUpper().EndsWith(".EXE"));
                    }
                    private static AssemblyName GetAssemblyName(string source, bool isFile)
                    {
                        AssemblyName asmName = null;
                        try
                        {
                            if (isFile)
                                asmName = GetAssemblyNameFromFile(source);
                            else
                                asmName = GetAssemblyNameFromQualifiedName(source);
                        }
                        catch (Exception err)
                        {
                            string ErrorFormatString = "Invalid Call to utility method 'GetAssemblyNameOrThrowException'\n" +
                                                       "Arguments passed in:\n" +
                                                       "=> Source:\n[{0}]\n" +
                                                       "=> isFile = {1}\n" +
                                                       "See inner exception(s) for more detail.";
                            throw new InvalidOperationException(string.Format(ErrorFormatString, source, isFile), err);
                        }
                        if (asmName == null)
                            throw new InvalidOperationException(asmName.Name + " Assembly Name object is null, but no other error was encountered!");
                        return asmName;
                    }
                    private static AssemblyName GetAssemblyNameFromFile(string file)
                    {
                        #region Validate parameters
                        if (string.IsNullOrWhiteSpace(file))
                            throw new ArgumentNullException("file", "given a null or empty string for a file name and path");
                        if (!System.IO.File.Exists(file))
                            throw new ArgumentException("File does not exsits", "file");
                        #endregion
                        AssemblyName AssemblyNameFromFile = null;
                        try
                        {
                            AssemblyNameFromFile = AssemblyName.GetAssemblyName(file);
                        }
                        catch (Exception err)
                        {
                            throw err;
                        }
                        return AssemblyNameFromFile;
                    }
                    private static AssemblyName GetAssemblyNameFromQualifiedName(string qualifiedAssemblyName)
                    {
                        #region Validate parameters
                        if (string.IsNullOrWhiteSpace(qualifiedAssemblyName))
                            throw new ArgumentNullException("qualifiedAssemblyName", "given a null or empty string for a qualified assembly name");
                        #endregion
                        AssemblyName AssemblyNameFromQualifiedAssemblyName = null;
                        try
                        {
                            AssemblyNameFromQualifiedAssemblyName = new AssemblyName(qualifiedAssemblyName);
                        }
                        catch (Exception err)
                        {
                            throw err;
                        }
                        return AssemblyNameFromQualifiedAssemblyName;
                    }
                    private static Assembly LoadAssembly(AssemblyName assemblyName)
                    {
                        Assembly asm = LoadAssemblyIntoCurrentAppDomain(assemblyName);
                        if (asm == null)
                            throw new InvalidOperationException(assemblyName.Name + " Assembly is null after loading but no other error was encountered!");
                        return asm;
                    }
                    private static Assembly LoadAssemblyIntoCurrentAppDomain(AssemblyName assemblyName)
                    {
                        #region Validation
                        if (assemblyName == null)
                            throw new ArgumentNullException("assemblyName", "Assembly name is null, must be valid Assembly Name Object");
                        #endregion
                        return LoadAssemblyIntoAppDomain(assemblyName, AppDomain.CurrentDomain);
                    }
                    private static Assembly LoadAssemblyIntoAppDomain(AssemblyName assemblyName, AppDomain appDomain)
                    {
                        #region Validation
                        if (assemblyName == null)
                            throw new ArgumentNullException("assemblyName", "Assembly name is null, must be valid Assembly Name Object");
                        if (appDomain == null)
                            throw new ArgumentNullException("appDomain", "Application Domain is null, must be a valid App Domain Object");
                        #endregion
                        return appDomain.Load(assemblyName);
                    }
                    private static Type GetTypeFromAssembly(string targetType, Assembly inAssembly)
                    {
                        #region Validate
                        if (string.IsNullOrWhiteSpace(targetType))
                            throw new ArgumentNullException("targetType", "Type name is null, empty, or whitespace, should be type's display name.");
                        if (inAssembly == null)
                            throw new ArgumentNullException("inAssembly", "Assembly is null, should be valid assembly");
                        #endregion
                        try
                        {
                            return inAssembly.GetType(targetType, true);
                        }
                        catch (Exception err)
                        {
                            string ErrorFormatMessage = "Unable to retrive type[{0}] from assembly [{1}], see inner exception.";
                            throw new InvalidOperationException(string.Format(ErrorFormatMessage, targetType, inAssembly), err);
                        }
                    }
                    private static Delegate CreateDelegateFrom(Object linkObject, Type ObjectType, Type DelegateType, MethodInfo TargetMethodInformation)
                    {
                        if (TargetMethodInformation.IsStatic & linkObject == null)
                        {
                            return CreateStaticMethodDelegate(DelegateType, TargetMethodInformation);
                        }
                        if (linkObject != null)
                        {
                            ValidateLinkObjectType(linkObject, ObjectType);
                        }
                        else
                        {
                            linkObject = CreateInstanceOfType(ObjectType, null);
                        }
                        return CreateInstanceMethodDelegate(linkObject, DelegateType, TargetMethodInformation);
                    }
                    private static Delegate CreateStaticMethodDelegate(Type DelegateType, MethodInfo TargetMethodInformation)
                    {
                        return Delegate.CreateDelegate(DelegateType, TargetMethodInformation);
                    }
                    private static void ValidateLinkObjectType(object linkObject, Type ObjectType)
                    {
                        if (!ObjectType.IsInstanceOfType(linkObject))
                        {
                            throw new ArgumentException(
                                string.Format("linkObject({0}) is not of type {1}", linkObject.GetType().Name, ObjectType.Name),
                                "linkObject",
                                new InvalidCastException(
                                    string.Format("Unable to cast object type {0} to object type {1}", linkObject.GetType().AssemblyQualifiedName, ObjectType.AssemblyQualifiedName),
                                    new NotSupportedException(
                                        "Conversions from one delegate object to another is not support with this version"
                                    )
                                )
                            );
                        }
                    }
                    private static Object CreateInstanceOfType(Type targetType, params Object[] parameters)
                    {
                        #region Validate
                        if (targetType == null)
                            throw new ArgumentNullException("targetType", "Target Type is null, must be valid System type.");
                        #endregion
                        try
                        {
                            return System.Activator.CreateInstance(targetType, parameters);
                        }
                        catch (Exception err)
                        {
                            string ErrorFormatMessage = "Invalid call to CreateInstanceOfType({0}, Object[])\n" +
                                                        "parameters found:\n" +
                                                        "{1}" +
                                                        "See inner exception for further information.";
                            string ParamaterInformationLine = GetParamaterLine(parameters);
                            throw new NotSupportedException(
                                string.Format(ErrorFormatMessage, targetType.Name, ParamaterInformationLine), err);
                        }
                    }
                    private static string GetParamaterLine(Object[] parameters)
                    {
                        if (parameters == null)
                            return "NONE\n";
                        string ParamaterFormatLine = "==> Paramater Type is {0} and object is {1}\n";
                        string ParamaterInformationLine = string.Empty;
                        foreach (object item in parameters)
                        {
                            ParamaterInformationLine += string.Format(ParamaterFormatLine, item.GetType().Name, item);
                        }
                        return ParamaterInformationLine;
                    }
                    private static Delegate CreateInstanceMethodDelegate(Object linkObject, Type DelegateType, MethodInfo TargetMethodInformation)
                    {
                        return Delegate.CreateDelegate(DelegateType, linkObject, TargetMethodInformation);
                    }
                }
                public string ObjectSource;
                public string ObjectFullName;
                public string ObjectMethodName;
                public string DelegateSource;
                public string DelegateFullName;
                public BindingFlags SuggestedBinding;
                public RuntimeDelegate(Delegate target)
                    : this(target.Method.DeclaringType.Assembly.FullName,
                           target.Method.DeclaringType.FullName,
                           target.Method.Name,
                           target.GetType().Assembly.FullName,
                           target.GetType().FullName,
                           RuntimeDelegateUtility.GetSuggestedBindingsForMethod(target.Method)) { }
 
                public RuntimeDelegate(
                    string objectSource,
                    string objectFullName,
                    string objectMethodName,
                    string delegateSource,
                    string delegateFullName,
                    BindingFlags suggestedBinding)
                    :this()
                {
                    #region Validate Arguments
                    if (string.IsNullOrWhiteSpace(objectSource))
                        throw new ArgumentNullException("ObjectSource");
                    if (string.IsNullOrWhiteSpace(objectFullName))
                        throw new ArgumentNullException("ObjectFullName");
                    if (string.IsNullOrWhiteSpace(objectMethodName))
                        throw new ArgumentNullException("ObjectMethodName");
                    if (string.IsNullOrWhiteSpace(delegateSource))
                        throw new ArgumentNullException("DelegateSource");
                    if (string.IsNullOrWhiteSpace(delegateFullName))
                        throw new ArgumentNullException("DelegateFullName");
                    #endregion
                    #region Copy values for properties
                    this.ObjectSource = objectSource;
                    this.ObjectFullName = objectFullName;
                    this.ObjectMethodName = objectMethodName;
                    this.DelegateSource = delegateSource;
                    this.DelegateFullName = delegateFullName;
                    this.SuggestedBinding = suggestedBinding;
                    #endregion
                }
                public Delegate ToDelegate()
                {
                    return ToDelegate(null);
                }
                public Delegate ToDelegate(Object linkObject)
                {
                    return RD.Runtime.RuntimeDelegate.RuntimeDelegateUtility.Create(this,  linkObject);
                }
            }
        }
