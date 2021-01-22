var myAssembly = typeof (Program).Assembly;
foreach (Type usedType in myAssembly.GetUsedTypes())
{
    if (typeof (Thread).IsAssignableFrom(usedType) ||
        typeof (ThreadPool).IsAssignableFrom(usedType) ||
        typeof (ThreadPriority).IsAssignableFrom(usedType)
        )
    {
        throw new SecurityException("Thread usage is banned here!");
    }
}
