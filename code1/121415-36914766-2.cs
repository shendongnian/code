    public static class TypeExtensions
    {
        public static Type GetDrivedType(this Type type, int maxSearchDepth = 10)
        {
            if (maxSearchDepth < 0)
                throw new ArgumentOutOfRangeException(nameof(maxSearchDepth), "Must be greater than 0.");
            const int skipFrames = 2;  // Skip the call to self, skip the call to the static Ctor.
            var stack = new StackTrace();
            var maxCount = Math.Min(maxSearchDepth + skipFrames + 1, stack.FrameCount);
            var frame = skipFrames;
            // Skip all the base class 'instance' ctor calls. 
            //
            while (frame < maxCount)
            {
                var method = stack.GetFrame(frame).GetMethod();
                var declaringType = method.DeclaringType;
                if (type.IsAssignableFrom(declaringType))
                    return declaringType;
                frame++;
            }
            return null;
        }
    }
