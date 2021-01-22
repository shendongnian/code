    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml.Serialization;
    
    [Serializable]
    [TypeConverter(typeof(VersionCodeConverter))]
    public class VersionCode : ICloneable, IComparable<VersionCode>, IEquatable<VersionCode>
    {
      [XmlAttribute] public int Major { get; private set; }
      [XmlAttribute] public int Minor { get; private set; }
      [XmlAttribute] public int Build { get; private set; } = -1;
      [XmlAttribute] public int Revision { get; private set; } = -1;
    
      public VersionCode() { }
    
      public VersionCode(int major, int minor, int build = 0, int revision = 0)
      {
        if (major < 0)
          throw new ArgumentOutOfRangeException(nameof(major), $"{nameof(major)} cannot be less than 0");
    
        if (minor < 0)
          throw new ArgumentOutOfRangeException(nameof(minor), $"{nameof(minor)} cannot be less than 0");
    
        if (build < 0)
          throw new ArgumentOutOfRangeException(nameof(build), $"{nameof(build)} cannot be less than 0");
    
        if (revision < 0)
          throw new ArgumentOutOfRangeException(nameof(revision), $"{nameof(revision)} cannot be less than 0");
    
        Major = major;
        Minor = minor;
        Build = build;
        Revision = revision;
      }
    
      public VersionCode(string version)
      {
        if (version == null)
          throw new ArgumentNullException(nameof(version));
    
        var components = new Stack<string>(version.Split('.'));
    
        if (components.Count < 2 || components.Count > 4)
          throw new ArgumentException(nameof(version));
    
        Major = int.Parse(components.Pop(), CultureInfo.InvariantCulture);
    
        if (Major < 0)
          throw new ArgumentOutOfRangeException(nameof(version), $"{nameof(Major)} cannot be less than 0");
    
        Minor = int.Parse(components.Pop(), CultureInfo.InvariantCulture);
    
        if (Minor < 0)
          throw new ArgumentOutOfRangeException(nameof(version), $"{nameof(Minor)} cannot be less than 0");
    
        if (!components.Any())
          return;
    
        Build = int.Parse(components.Pop(), CultureInfo.InvariantCulture);
    
        if (Build < 0)
          throw new ArgumentOutOfRangeException(nameof(version), $"{nameof(Build)} cannot be less than 0");
    
        if (!components.Any())
          return;
    
        Revision = int.Parse(components.Pop(), CultureInfo.InvariantCulture);
    
        if (Revision < 0)
          throw new ArgumentOutOfRangeException(nameof(version), $"{nameof(Revision)} cannot be less than 0");
      }
    
      public object Clone()
        => new VersionCode(Major, Minor, Build, Revision);
    
      public int CompareTo(VersionCode version) 
        => Major != version.Major ? Major.CompareTo(version.Major)
          : Minor != version.Minor ? Minor.CompareTo(version.Minor)
            : Build != version.Build ? Build.CompareTo(version.Build)
              : Revision.CompareTo(version.Revision);
    
      public override bool Equals(object obj)
        => obj is VersionCode && Equals((VersionCode)obj);
    
      public bool Equals(VersionCode version)
        => Major == version.Major
        && Minor == version.Minor
        && Build == version.Build
        && Revision == version.Revision;
    
      public override int GetHashCode()
      {
        var hash = 0;
    
        hash |= (Major & 15) << 0x1c;
        hash |= (Minor & 0xff) << 20;
        hash |= (Build & 0xff) << 12;
        hash |= (Revision & 0xfff);
    
        return hash;
      }
    
      public static bool operator ==(VersionCode v1, VersionCode v2)
        => ReferenceEquals(v1, null) ? ReferenceEquals(v2, null) : v1.Equals(v2);
    
      public static bool operator !=(VersionCode v1, VersionCode v2)
        => !(v1 == v2);
    
      public static bool operator >(VersionCode v1, VersionCode v2)
        => v2 < v1;
    
      public static bool operator >=(VersionCode v1, VersionCode v2)
        => v2 <= v1;
    
      public static bool operator <(VersionCode v1, VersionCode v2)
        => !ReferenceEquals(v1, null) && v1.CompareTo(v2) < 0;
    
      public static bool operator <=(VersionCode v1, VersionCode v2)
        => !ReferenceEquals(v1, null) && v1.CompareTo(v2) <= 0;
    
      public override string ToString()
        => Build < 0 ? $"{Major}.{Minor}"
          : Revision < 0 ? $"{Major}.{Minor}.{Build}"
            : $"{Major}.{Minor}.{Build}.{Revision}";
    }
    
    public class VersionCodeConverter : TypeConverter
    {
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        => sourceType == typeof(string)
        || base.CanConvertFrom(context, sourceType);
    
      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
        var version = value as string;
    
        return version != null 
          ? new VersionCode(version)
          : base.ConvertFrom(context, culture, value);
      }
    }
