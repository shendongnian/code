    private IEnumerator PlayRandomly ()
    {
        var clipList = clips.ToList();
        while(true)
        {
            clipList.Shuffle();
            foreach(var randClip in clipList)
            {
                animator.Play(randClip.name);
                yield return new WaitForSeconds(randClip.length);
            }
        }
    }
    public static class IListExtensions 
    {
        /// <summary>
        /// Shuffles the element order of the specified list.
        /// </summary>
        public static void Shuffle<T>(this IList<T> ts) {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i) {
                var r = UnityEngine.Random.Range(i, count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }
    }
