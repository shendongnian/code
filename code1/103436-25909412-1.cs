    <style type="text/css">.csharpcode, .csharpcode pre
    {
    	font-size: 13.3333px;
    	font-width: 400;
    	color: black;
    	font-family: "Courier New";
    }
    .csharpcode pre { margin: 0px; }
    .csharpcode .comment { color: #008000; }
    .csharpcode .comment2 { color: #808080; }
    .csharpcode .type { color: #2B91AF; }
    .csharpcode .keyword { color: #0000FF; }
    .csharpcode .string { color: #A31515; }
    .csharpcode .preproc { color: #0000FF; }
    </style>
    <div class='csharpcode'>Code:<pre style='border:1px dashed #CCCCCC;overflow-x:auto;overflow-y:hidden;background:#f0f0f0;padding:0px;color:#000000;text-align:left;line-height20px;color:#000000;word-wrap:normal;'><span class='comment'>/*
    //using Timer with callback on System.Threading namespace
    //  Timer(TimerCallback callback, object state, int dueTime, int period);
    //      TimerCallback: delegate to callback on timer lapse
    //      state: an object containig information for the callback
    //      dueTime: time delay before callback is invoked; in milliseconds; 0 immediate
    //      period: interval between invocation of callback; System.Threading.Timeout.Infinity to disable
    // EXCEPTIONS:
    //      ArgumentOutOfRangeException: negative duration or period
    //      ArgumentNullException: callback parameter is null 
    */</span>
    <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;summary&gt;</span><span class='comment'></span>
    <span class='comment'>// Example </span>
    <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;/summary&gt;</span><span class='comment'></span>
    <span class='keyword'>public</span> <span class='keyword'>class</span> <span class='type'>Program</span>
    {
        <span class='keyword'>public</span> <span class='keyword'>void</span> Main()
        {
            <span class='type'>var</span> te = <span class='keyword'>new</span> <span class='type'>TimerExample</span>(1000, 2000, 2);
        }
    }
    <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;summary&gt;</span><span class='comment'></span>
    <span class='comment2'>///</span><span class='comment'> Timer example</span>
    <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;/summary&gt;</span><span class='comment'></span>
    <span class='keyword'>public</span> <span class='keyword'>class</span> <span class='type'>TimerExample</span>
    {
        <span class='keyword'>public</span> TimerExample(<span class='keyword'>int</span> delayTime, <span class='keyword'>int</span> intervalTime, <span class='keyword'>int</span> treshold)
        {
            <span class='keyword'>this</span>.DelayTime = delayTime;
            <span class='keyword'>this</span>.IntervalTime = intervalTime;
            <span class='keyword'>this</span>.Treshold = treshold;
            <span class='keyword'>this</span>.<span class='type'>Timer</span> = <span class='keyword'>new</span> <span class='type'>Timer</span>(<span class='keyword'>this</span>.TimerCallbackWorker, <span class='keyword'>new</span> <span class='type'>StateInfo</span>(), delayTime, intervalTime);
        }
        <span class='keyword'>public</span> <span class='keyword'>int</span> DelayTime
        {
            <span class='keyword'>get</span>;
            <span class='keyword'>set</span>;
        }
        <span class='keyword'>public</span> <span class='keyword'>int</span> IntervalTime
        {
            <span class='keyword'>get</span>;
            <span class='keyword'>set</span>;
        }
        <span class='keyword'>public</span> <span class='type'>Timer</span> Timer
        {
            <span class='keyword'>get</span>;
            <span class='keyword'>set</span>;
        }
        <span class='keyword'>public</span> <span class='type'>StateInfo</span> SI
        {
            <span class='keyword'>get</span>;
            <span class='keyword'>set</span>;
        }
        <span class='keyword'>public</span> <span class='keyword'>int</span> Treshold
        {
            <span class='keyword'>get</span>;
            <span class='keyword'>private</span> <span class='keyword'>set</span>;
        }
        <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;summary&gt;</span><span class='comment'></span>
        <span class='comment2'>///</span><span class='comment'> timer callback </span>
        <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;/summary&gt;</span><span class='comment'></span>
        <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;param name=&quot;state&quot;&gt;</span><span class='comment'>state information</span><span class='comment'></span><span class='comment2'>&lt;/param&gt;</span><span class='comment'></span>
        <span class='keyword'>public</span> <span class='keyword'>void</span> TimerCallbackWorker(<span class='keyword'>object</span> state)
        {
            <span class='type'>var</span> si = state <span class='keyword'>as</span> <span class='type'>StateInfo</span>;
            <span class='keyword'>if</span> (si == <span class='keyword'>null</span>)
            {
                <span class='keyword'>throw</span> <span class='keyword'>new</span> <span class='type'>ArgumentNullException</span>(<span class='string'>&quot;state&quot;</span>);
            }
            si.ExecutionCounter++;
            <span class='keyword'>if</span> (si.ExecutionCounter &gt; <span class='keyword'>this</span>.Treshold)
            {
                <span class='keyword'>this</span>.<span class='type'>Timer</span>.Change(<span class='type'>Timeout</span>.Infinite, <span class='type'>Timeout</span>.Infinite);
                <span class='type'>Console</span>.WriteLine(<span class='string'>&quot;-Timer stop, execution reached treshold {0}&quot;</span>, <span class='keyword'>this</span>.Treshold);
            }
            <span class='keyword'>else</span>
            {
                <span class='type'>Console</span>.WriteLine(<span class='string'>&quot;{0} lapse, Time {1}&quot;</span>, si.ExecutionCounter, si.ToString());
            }
        }
        <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;summary&gt;</span><span class='comment'></span>
        <span class='comment2'>///</span><span class='comment'> state information</span>
        <span class='comment2'>///</span><span class='comment'> </span><span class='comment2'>&lt;/summary&gt;</span><span class='comment'></span>
        <span class='keyword'>public</span> <span class='keyword'>class</span> <span class='type'>StateInfo</span>
        {
            <span class='keyword'>public</span> <span class='keyword'>int</span> ExecutionCounter
            {
                <span class='keyword'>get</span>;
                <span class='keyword'>set</span>;
            }
            <span class='keyword'>public</span> <span class='type'>DateTime</span> LastRun
            {
                <span class='keyword'>get</span>
                {
                    <span class='keyword'>return</span> DateTime.Now;
                }
            }
            <span class='keyword'>public</span> <span class='keyword'>override</span> <span class='keyword'>string</span> ToString()
            {
                <span class='keyword'>return</span> this.LastRun.ToString();
            }
        }
    }
    <span class='comment'>// Result:</span>
    <span class='comment'>// </span>
    <span class='comment'>//  1 lapse, Time 2015-02-13 01:28:39 AM</span>
    <span class='comment'>//  2 lapse, Time 2015-02-13 01:28:41 AM</span>
    <span class='comment'>//  -Timer stop, execution reached treshold 2</span>
    <span class='comment'>// </span><!--[if IE]>
    <![endif]--></pre></div>
