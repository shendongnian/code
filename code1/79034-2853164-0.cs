       /// <summary>
        /// Gets the length of the video.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        static public bool GetVideoLength(string fileName, out double length)
        {
            DirectShowLib.FilterGraph graphFilter = new DirectShowLib.FilterGraph();
            DirectShowLib.IGraphBuilder graphBuilder;
            DirectShowLib.IMediaPosition mediaPos;
            length = 0.0;
            try
            {
                graphBuilder = (DirectShowLib.IGraphBuilder)graphFilter;
                graphBuilder.RenderFile(fileName, null);
                mediaPos = (DirectShowLib.IMediaPosition)graphBuilder;
                mediaPos.get_Duration(out length);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                mediaPos = null;
                graphBuilder = null;
                graphFilter = null;
            }
        }
