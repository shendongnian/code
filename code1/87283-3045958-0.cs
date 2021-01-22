    [TestFixture]
    public class VbaRandomTests
    {
        // Random numbers generated from a known seed from VB6
        [TestCase(1, new[] { 0.333575300f, 0.068163870f, 0.593829300f, 0.766039500f, 0.189289400f, 0.537398600f, 0.326994400f, 0.393937000f, 0.073419150f, 0.831542500f, 0.854963000f, 0.828829900f, 0.962344000f, 0.833957400f, 0.090149820f, 0.645974500f, 0.192794900f, 0.346950500f, 0.188133400f, 0.691135000f })]
        [TestCase(32, new[] { 0.579913200f, 0.579150200f, 0.310870300f, 0.864916400f, 0.142658500f, 0.927291200f, 0.407316600f, 0.402970200f, 0.296319500f, 0.412841300f, 0.361066500f, 0.560519300f, 0.017275630f, 0.919162500f, 0.084534590f, 0.912820200f, 0.642257800f, 0.248561900f, 0.733299400f, 0.305637000f })]
        [TestCase(327680, new[] { 0.882708600f, 0.733264000f, 0.661029000f, 0.376940400f, 0.919086800f, 0.660506500f, 0.020170630f, 0.126908200f, 0.437005600f, 0.053283210f, 0.252240800f, 0.449496400f, 0.662844500f, 0.044955970f, 0.519654200f, 0.169961300f, 0.183334400f, 0.687831900f, 0.227989400f, 0.384067200f })]
        public void generates_same_results_as_VB6(int seed, float[] values)
        {
            VBMath.Rnd(-1);
            VBMath.Randomize(seed);
            float[] results = new float[values.Length];
            for (int index = 0; index < results.Length; index++)
            {
                results[index] = VBMath.Rnd();
            }
            CollectionAssert.AreEqual(values, results, new FloatEpsilonComparer(0.0000001f));
        }
        private class FloatEpsilonComparer
            : IComparer<float>, IComparer
        {
            private readonly float _epsilon;
            public FloatEpsilonComparer(float epsilon)
            {
                _epsilon = epsilon;
            }
            public int Compare(float x, float y)
            {
                float difference = x - y;
                if (Math.Abs(difference) < _epsilon)
                {
                    return 0;
                }
                if (x < y)
                {
                    return -1;
                }
                return 1;
            }
            public int Compare(object x, object y)
            {
                float xF = Convert.ToSingle(x);
                float yF = Convert.ToSingle(y);
                return Compare(xF, yF);
            }
        }
    }
