    var targetType = typeof(IComparable);
    var errors = new List<Exception>();
    var c = Directory.GetFiles(@"c:\windows\assembly", "*.dll", SearchOption.AllDirectories).ToList()
        .ConvertAll(f => Path.GetFileNameWithoutExtension(f))
        .Where(f => !f.EndsWith(".ni"))
        .Distinct().ToList()
        .ConvertAll(f => { try { return Assembly.ReflectionOnlyLoad(f); } catch (Exception ex) { errors.Add(ex); return null; } })
        .Where(a => a != null)
        .SelectMany(a => { try { return a.GetTypes(); } catch (Exception ex) { errors.Add(ex); return new Type[] { }; } })
        .Where(t => targetType.IsAssignableFrom(t));
