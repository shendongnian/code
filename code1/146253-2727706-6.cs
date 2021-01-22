    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    using AForge;
    using AForge.Imaging;
    using AForge.Imaging.Filters;
    using AForge.Imaging.Textures;
    using AForge.Math.Geometry;
    
    namespace CDIO.Library
    {
        public class Blobsprocessing
        {
            Bitmap image;
            BlobCounter BlobCounter;
            Blob[] blobs;
            List<Polygon> hulls;
    
            public Blobsprocessing(Bitmap image)
            {
                this.image = image; 
            }
    
            public void Process()
            {
                BlobCounter = new BlobCounter();
    
                processBlobs();
                extractConvexHull();
            }
            public List<Polygon> getHulls()
            {
                return hulls;
            }
    
            private void processBlobs()
            {
                BlobCounter.FilterBlobs = true;
                BlobCounter.MinWidth = 5;
                BlobCounter.MinHeight = 5;
                // set ordering options
                BlobCounter.ObjectsOrder = ObjectsOrder.Size;
                // process binary image
                BlobCounter.ProcessImage(image);
    
                blobs = BlobCounter.GetObjectsInformation();
            }
    
            private void extractConvexHull()
            {
                GrahamConvexHull hullFinder = new GrahamConvexHull();
    
                // process each blob
                hulls = new List<Polygon>();
                foreach (Blob blob in blobs)
                {
                    List<IntPoint> leftPoints, rightPoints, edgePoints;
                    edgePoints = new List<IntPoint>();
    
                    // get blob's edge points
                    BlobCounter.GetBlobsLeftAndRightEdges(blob,
                        out leftPoints, out rightPoints);
    
                    edgePoints.AddRange(leftPoints);
                    edgePoints.AddRange(rightPoints);
    
                    // blob's convex hull
                    List<IntPoint> hull = hullFinder.FindHull(edgePoints);
                    hulls.Add(new Polygon(hull));
                }
            }
        }
    }
